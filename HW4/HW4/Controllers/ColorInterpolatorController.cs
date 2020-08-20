using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.Mvc;

/* Interpolate from starting value = 10 to ending value = 90, n = 9,
 * Step = (end - start)/(n-1)
 * val = start
 * if i = 0; start
 * if i = 1; start + 1 * step
 * if i = 2; start + 2 * step
 * style = "background-color: _____" using table <td>*/



namespace HW4.Controllers
{

    // From Greg's answer: https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv/1626175
    // And Wikipedia: https://en.wikipedia.org/wiki/HSL_and_HSV
    
    public class ColorInterpolatorController : Controller
    { 
        IList<Color> ColorList = new List<Color>();
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
        public ActionResult Create()
        {
            ViewBag.ColorList = ColorList;
            return View();
        }

        // Post: ColorInterpolator
        [HttpPost]
        public ActionResult Create(string FirstColor, string SecondColor, int NumColor)
        {
            if (ModelState.IsValid)
            {
                Color firstcolor = ColorTranslator.FromHtml(FirstColor);
                Color secondcolor = ColorTranslator.FromHtml(SecondColor);
                ColorList.Add(firstcolor);
                ColorToHSV(firstcolor, out double h1, out double s1, out double v1);
                ColorToHSV(secondcolor, out double h2, out double s2, out double v2);
                double changeH = (h2 - h1) / (NumColor - 1);
                double changeS = (s2 - s1) / (NumColor - 1);
                double changeV = (v2 - v1) / (NumColor - 1);
                double tempH = h1;
                double tempS = s1;
                double tempV = v1;
                for(int i = 0; i < NumColor - 2; i++)
                {
                    Color NewColor = ColorFromHSV(tempH + changeH, tempS + changeS, tempV + changeV);
                    ColorList.Add(NewColor);
                    tempH += changeH;
                    tempS += changeS;
                    tempV += changeV;
                }
                ColorList.Add(secondcolor);
                ViewBag.ColorList = ColorList;
                ViewBag.Success = true;
                return View();
            }
            else
            {
                return RedirectToAction("Create", "ColorInterpolator");
            }
        }
    }

}

