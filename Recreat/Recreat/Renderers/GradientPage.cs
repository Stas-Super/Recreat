﻿using RecreatMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RecreatMobile.Renderers
{
    public class GradientPage : StackLayout
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
        public GradientColorStackMode Mode { get; set; }
    }
}
