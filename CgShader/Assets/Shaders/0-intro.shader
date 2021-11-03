Shader "First Shader" {
    SubShader {
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            float4 vert(float4 vertexPos: POSITION) : SV_POSITION {
                // x, y, z plus w offset is the float4 input
                return UnityObjectToClipPos(vertexPos *float4(1,0.5,1,1));
            }

            float4 frag(void) : COLOR {
                return float4(1.0, 1.0, 0.0, 1.0);
                // red, green, blue, transparency
                // Magenta: 1, 0, 1
                // Yellow: 1, 1, 0
            }

            ENDCG

        }
    }
}