Shader "Custom/Outline" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth("Outline Width", Range(0, 0.1)) = 0.005
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color;
                float2 _OutlineColor;
                float _OutlineWidth;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    // Draw outline
                    float2 texelSize = 1.0 / _ScreenParams.xy;
                    float4 color = _OutlineColor;
                    color *= texelSize * _OutlineWidth * 50;
                    float4 outline = tex2D(_MainTex, i.uv + float2(-1, -1) * texelSize) +
                                     tex2D(_MainTex, i.uv + float2(0, -1) * texelSize) +
                                     tex2D(_MainTex, i.uv + float2(1, -1) * texelSize) +
                                     tex2D(_MainTex, i.uv + float2(-1, 0) * texelSize) +
                                     tex2D(_MainTex, i.uv + float2(1, 0) * texelSize) +
                                     tex2D(_MainTex, i.uv + float2(-1, 1) * texelSize) +
                                     tex2D(_MainTex, i.uv + float2(0, 1) * texelSize) +
                                     tex2D(_MainTex, i.uv + float2(1, 1) * texelSize);
                    outline /= 8.0;
                    clip(1 - step(0.01, length(outline - tex2D(_MainTex, i.uv))));

                    // Draw object
                    fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                    return col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
