Shader "Blending" {
    SubShader {
        Pass {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            float4 vert(float4 vertexPos: POSITION): SV_POSITION {

                return UnityObjectToClipPos(vertexPos);

            }

            float4 frag(void) : COLOR {
                return float4(0,0,1,0.7);
            }

            ENDCG

        }
    }
}