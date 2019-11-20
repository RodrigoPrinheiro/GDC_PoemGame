using System;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

// Script has the base from https://github.com/Unity-Technologies/PostProcessing/wiki/Writing-Custom-Effects
[Serializable]
[PostProcess(typeof(PostProcessColorScaleRenderer), PostProcessEvent.BeforeStack, "PineTree/Color Scale")]
public sealed class ColorScale : PostProcessEffectSettings
{
    // Insert post process settings here
    [Range(0f, 1f), Tooltip("Colorscale effect intensity.")]
    public FloatParameter blend = new FloatParameter { value = 0.5f };
    public ColorParameter darkest = new ColorParameter { value = Color.black};
    public ColorParameter dark = new ColorParameter { value = Color.grey};
    public ColorParameter midtones = new ColorParameter { value = Color.grey};
    public ColorParameter light = new ColorParameter { value = Color.yellow};
    public ColorParameter lightest = new ColorParameter { value = Color.white};

    public override bool IsEnabledAndSupported(PostProcessRenderContext context)
    {
        // Turns off the effect if blend value is 0
        return enabled.value && blend.value > 0f;
    }
}

public sealed class PostProcessColorScaleRenderer : PostProcessEffectRenderer<ColorScale>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/PineTree/ColorScale"));
        // Set values here
        sheet.properties.SetFloat("_Blend", settings.blend);
        sheet.properties.SetColor("_SDarkest", settings.darkest);
        sheet.properties.SetColor("_SDark", settings.dark);
        sheet.properties.SetColor("_SMidtones", settings.midtones);
        sheet.properties.SetColor("_SLight", settings.light);
        sheet.properties.SetColor("_SLightest", settings.lightest);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}