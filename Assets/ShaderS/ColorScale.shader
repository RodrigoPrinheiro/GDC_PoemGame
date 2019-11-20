Shader "Hidden/PineTree/ColorScale"
{
    HLSLINCLUDE

        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        float4 _Blend;
		float4 _SDarkest;
		float4 _SDark;
		float4 _SMidtones;
		float4 _SLight;
		float4 _SLightest;

        float4 Frag(VaryingsDefault i) : SV_Target
        {
            float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

			float lum = dot(color, float3(0.3, 0.59, 0.11));

			int c = lum * 4;

			float3 col = lerp(_SDarkest, _SDark, saturate(c));
			col = lerp(col, _SMidtones, saturate(c - 1.0));
			col = lerp(col, _SLight, saturate(c - 2.0));
			col = lerp(col, _SLightest, saturate(c - 3.0));

			float4 finalColor = float4(lerp(col, color, _Blend), 1.0);
			return finalColor;
        }
    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}
