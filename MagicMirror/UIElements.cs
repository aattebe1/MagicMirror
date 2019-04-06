/* 
 * UIElements.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Sets up the UI elements for the magic mirror. This is an inelegant
 *              solution to cleaning up the code in the ProgWindow.cs file, but it
 *              accomplishes the intended task.
 * 
 */

namespace MagicMirror
{
	public static class UIElements
    {
		/* Sets the ProgLabel[] properties */
        public static void SetupProgLabels(ref Gtk.Label[] ProgLabels, Gdk.Color FontColor)
        {
            ProgLabels[0] = new Gtk.Label();
            ProgLabels[0].SetAlignment((float)0.0, (float)0.0);
            ProgLabels[0].CanFocus = false;
            ProgLabels[0].Justify = Gtk.Justification.Left;
            ProgLabels[0].Selectable = false;
            ProgLabels[0].UseUnderline = false;
            ProgLabels[0].UseMarkup = false;
            ProgLabels[0].Wrap = false;
            ProgLabels[0].LineWrap = false;
            ProgLabels[0].Xpad = 10;
            ProgLabels[0].Ypad = 10;
            ProgLabels[0].Visible = true;
            ProgLabels[0].ModifyFg(Gtk.StateType.Normal, FontColor);
            ProgLabels[0].ModifyFont(Pango.FontDescription.FromString("Sans Bold 30"));

            ProgLabels[1] = new Gtk.Label();
            ProgLabels[1].SetAlignment((float)1.0, (float)0.0);
            ProgLabels[1].CanFocus = false;
            ProgLabels[1].Justify = Gtk.Justification.Right;
            ProgLabels[1].Selectable = false;
            ProgLabels[1].UseUnderline = false;
            ProgLabels[1].UseMarkup = false;
            ProgLabels[1].Wrap = false;
            ProgLabels[1].LineWrap = false;
            ProgLabels[1].Xpad = 10;
            ProgLabels[1].Ypad = 10;
            ProgLabels[1].Visible = true;
            ProgLabels[1].ModifyFg(Gtk.StateType.Normal, FontColor);
            ProgLabels[1].ModifyFont(Pango.FontDescription.FromString("Sans Bold 30"));

            ProgLabels[2] = new Gtk.Label();
            ProgLabels[2].SetAlignment((float)1.0, (float)0.0);
            ProgLabels[2].CanFocus = false;
            ProgLabels[2].Justify = Gtk.Justification.Right;
            ProgLabels[2].Selectable = false;
            ProgLabels[2].UseUnderline = false;
            ProgLabels[2].UseMarkup = false;
            ProgLabels[2].Wrap = false;
            ProgLabels[2].LineWrap = false;
            ProgLabels[2].Xpad = 10;
            ProgLabels[2].Ypad = 1;
            ProgLabels[2].Visible = true;
            ProgLabels[2].ModifyFg(Gtk.StateType.Normal, FontColor);
            ProgLabels[2].ModifyFont(Pango.FontDescription.FromString("Sans Bold 39"));

            ProgLabels[3] = new Gtk.Label();
            ProgLabels[3].SetAlignment((float)1.0, (float)0.0);
            ProgLabels[3].CanFocus = false;
            ProgLabels[3].Justify = Gtk.Justification.Right;
            ProgLabels[3].Selectable = false;
            ProgLabels[3].UseUnderline = false;
            ProgLabels[3].UseMarkup = false;
            ProgLabels[3].Wrap = false;
            ProgLabels[3].LineWrap = false;
            ProgLabels[3].Xpad = 10;
            ProgLabels[3].Ypad = 1;
            ProgLabels[3].Visible = true;
            ProgLabels[3].ModifyFg(Gtk.StateType.Normal, FontColor);
            ProgLabels[3].ModifyFont(Pango.FontDescription.FromString("Sans Bold 28"));

            ProgLabels[4] = new Gtk.Label();
            ProgLabels[4].SetAlignment((float)1.0, (float)0.0);
            ProgLabels[4].CanFocus = false;
            ProgLabels[4].Justify = Gtk.Justification.Right;
            ProgLabels[4].Selectable = false;
            ProgLabels[4].UseUnderline = false;
            ProgLabels[4].UseMarkup = false;
            ProgLabels[4].Wrap = false;
            ProgLabels[4].LineWrap = false;
            ProgLabels[4].Xpad = 10;
            ProgLabels[4].Ypad = 1;
            ProgLabels[4].Visible = true;
            ProgLabels[4].ModifyFg(Gtk.StateType.Normal, FontColor);
            ProgLabels[4].ModifyFont(Pango.FontDescription.FromString("Sans Bold 10"));

			for (int n = 5; n < ProgLabels.Length; n++)
            {
                ProgLabels[n] = new Gtk.Label();
                ProgLabels[n].SetAlignment((float)0.0, (float)0.05);
                ProgLabels[n].CanFocus = false;
                ProgLabels[n].Justify = Gtk.Justification.Left;
                ProgLabels[n].WidthRequest = 500;
                ProgLabels[n].Selectable = false;
                ProgLabels[n].UseUnderline = false;
                ProgLabels[n].UseMarkup = true;
                ProgLabels[n].Wrap = true;
                ProgLabels[n].LineWrap = true;
                ProgLabels[n].LineWrapMode = Pango.WrapMode.Word;
                ProgLabels[n].Xpad = 10;
                ProgLabels[n].Ypad = 10;
                ProgLabels[n].Visible = true;
                ProgLabels[n].ModifyFg(Gtk.StateType.Normal, FontColor);
                ProgLabels[n].ModifyFont(Pango.FontDescription.FromString("Luxi Sans Bold 14"));
            }
        }

		/* Sets the SpaceLabel[] properties */
        public static void SetupSpaceLabels(ref Gtk.Label[] SpaceLabel, Gdk.Color FontColor)
        {
            SpaceLabel[0] = new Gtk.Label();
            SpaceLabel[0].SetAlignment((float)0.0, (float)0.05);
            SpaceLabel[0].CanFocus = false;
            SpaceLabel[0].Justify = Gtk.Justification.Left;
            SpaceLabel[0].WidthRequest = 500;
            SpaceLabel[0].Selectable = false;
            SpaceLabel[0].UseUnderline = false;
            SpaceLabel[0].UseMarkup = true;
            SpaceLabel[0].Wrap = true;
            SpaceLabel[0].LineWrap = true;
            SpaceLabel[0].LineWrapMode = Pango.WrapMode.Word;
            SpaceLabel[0].Xpad = 10;
            SpaceLabel[0].Ypad = 10;
            SpaceLabel[0].Visible = true;
            SpaceLabel[0].ModifyFg(Gtk.StateType.Normal, FontColor);
            SpaceLabel[0].ModifyFont(Pango.FontDescription.FromString("Luxi Sans Bold 20"));
            SpaceLabel[0].Text = " ";

            SpaceLabel[1] = new Gtk.Label();
            SpaceLabel[1].SetAlignment((float)0.0, (float)0.05);
            SpaceLabel[1].CanFocus = false;
            SpaceLabel[1].Justify = Gtk.Justification.Left;
            SpaceLabel[1].WidthRequest = 500;
            SpaceLabel[1].Selectable = false;
            SpaceLabel[1].UseUnderline = false;
            SpaceLabel[1].UseMarkup = true;
            SpaceLabel[1].Wrap = true;
            SpaceLabel[1].LineWrap = true;
            SpaceLabel[1].LineWrapMode = Pango.WrapMode.Word;
            SpaceLabel[1].Xpad = 10;
            SpaceLabel[1].Ypad = 10;
            SpaceLabel[1].Visible = true;
            SpaceLabel[1].ModifyFg(Gtk.StateType.Normal, FontColor);
            SpaceLabel[1].ModifyFont(Pango.FontDescription.FromString("Luxi Sans Bold 30"));
            SpaceLabel[1].Text = " ";

            SpaceLabel[2] = new Gtk.Label();
            SpaceLabel[2].SetAlignment((float)0.0, (float)0.05);
            SpaceLabel[2].CanFocus = false;
            SpaceLabel[2].Justify = Gtk.Justification.Right;
            SpaceLabel[2].WidthRequest = 500;
            SpaceLabel[2].Selectable = false;
            SpaceLabel[2].UseUnderline = false;
            SpaceLabel[2].UseMarkup = true;
            SpaceLabel[2].Wrap = true;
            SpaceLabel[2].LineWrap = true;
            SpaceLabel[2].LineWrapMode = Pango.WrapMode.Word;
            SpaceLabel[2].Xpad = 10;
            SpaceLabel[2].Ypad = 10;
            SpaceLabel[2].Visible = true;
            SpaceLabel[2].ModifyFg(Gtk.StateType.Normal, FontColor);
            SpaceLabel[2].ModifyFont(Pango.FontDescription.FromString("Luxi Sans Bold 10"));
            SpaceLabel[2].Text = " ";

            SpaceLabel[3] = new Gtk.Label();
            SpaceLabel[3].SetAlignment((float)0.0, (float)0.05);
            SpaceLabel[3].CanFocus = false;
            SpaceLabel[3].Justify = Gtk.Justification.Right;
            SpaceLabel[3].WidthRequest = 500;
            SpaceLabel[3].Selectable = false;
            SpaceLabel[3].UseUnderline = false;
            SpaceLabel[3].UseMarkup = true;
            SpaceLabel[3].Wrap = true;
            SpaceLabel[3].LineWrap = true;
            SpaceLabel[3].LineWrapMode = Pango.WrapMode.Word;
            SpaceLabel[3].Xpad = 10;
            SpaceLabel[3].Ypad = 10;
            SpaceLabel[3].Visible = true;
            SpaceLabel[3].ModifyFg(Gtk.StateType.Normal, FontColor);
            SpaceLabel[3].ModifyFont(Pango.FontDescription.FromString("Luxi Sans Bold 100"));
            SpaceLabel[3].Text = " ";
        }

		/* Sets the SensorLabel properties */
        public static void SetupSensorLabel(ref Gtk.Label SensorLabel, Gdk.Color FontColor)
        {
            SensorLabel.SetAlignment((float)0.5, (float)0.0);
            SensorLabel.CanFocus = false;
            SensorLabel.Justify = Gtk.Justification.Left;
            SensorLabel.WidthRequest = 500;
            SensorLabel.Selectable = false;
            SensorLabel.UseUnderline = false;
            SensorLabel.UseMarkup = false;
            SensorLabel.Wrap = false;
            SensorLabel.LineWrap = false;
            SensorLabel.Xpad = 10;
            SensorLabel.Ypad = 10;
            SensorLabel.Visible = true;
            SensorLabel.ModifyFg(Gtk.StateType.Normal, FontColor);
            SensorLabel.ModifyFont(Pango.FontDescription.FromString("Luxi Sans Bold 15"));
        }

        /* Configures the condition image */
        public static void SetupImages(ref Gtk.Image[] ProgImage)
        {
            for (int n = 0; n < ProgImage.Length; n++)
            {
                ProgImage[n] = new Gtk.Image();
                ProgImage[n].CanFocus = false;
                ProgImage[n].Visible = true;
            }

            ProgImage[0] = Gtk.Image.LoadFromResource("MagicMirror.images.default.gif");
            ProgImage[1] = Gtk.Image.LoadFromResource("MagicMirror.images.door1.png");
            ProgImage[1].Xpad = 10;
            ProgImage[1].Yalign = (float)1.0;
        }

		/* Configures the image frames */
        public static void SetupFrames(ref Gtk.Frame[] ProgFrame, ref Gtk.Image[] ProgImage)
        {
            for (int n = 0; n < ProgFrame.Length; n++)
            {
                ProgFrame[n] = new Gtk.Frame();
                ProgFrame[n].ShadowType = Gtk.ShadowType.None;
                ProgFrame[n].LabelXalign = (float)0.0;
                ProgFrame[n].CanFocus = false;
                ProgFrame[n].Visible = true;
                ProgFrame[n].Add(ProgImage[n]);
            }

            ProgFrame[0].LabelYalign = (float)0.5;
            ProgFrame[1].LabelYalign = (float)1.0;
        }

        /* Configures the images' alignments */
        public static void SetupAlignments(ref Gtk.Alignment[] ProgAlignment, ref Gtk.Frame[] ProgFrame)
        {
            ProgAlignment[0] = new Gtk.Alignment((float)1.0, (float)0.0, (float)0.0, (float)0.0);
            ProgAlignment[1] = new Gtk.Alignment((float)0.0, (float)1.0, (float)0.0, (float)0.0);

            for (int n = 0; n < ProgFrame.Length; n++)
            {
                ProgAlignment[n].CanFocus = false;
                ProgAlignment[n].Visible = true;
                ProgAlignment[n].Add(ProgFrame[n]);
            }
        }

        /* Configures the box containers */
        public static void SetupBoxes(ref Gtk.Box[] ProgBox, ref Gtk.Label[] ProgLabels,
			ref Gtk.Label[] SpaceLabel, ref Gtk.Alignment[] ProgAlignment)
        {
            ProgBox[0] = new Gtk.HBox(false, 0);    // Date/Time box
            ProgBox[1] = new Gtk.VBox(false, 0);    // Weather condition box
            ProgBox[2] = new Gtk.VBox(false, 0);    // Weather box
            ProgBox[3] = new Gtk.VBox(false, 0);    // News box
            ProgBox[4] = new Gtk.HBox(false, 0);    // Sensor box
            ProgBox[5] = new Gtk.VBox(false, 0);    // Program box

            for (int n = 0; n < ProgBox.Length; n++)
            {
                ProgBox[n].CanFocus = false;
                ProgBox[n].Visible = true;
                ProgBox[n].Homogeneous = false;
            }

            ProgBox[0].PackStart(ProgLabels[0], true, true, 0);
            ProgBox[0].PackStart(ProgLabels[1], true, true, 0);
            ProgBox[1].PackStart(ProgLabels[4], true, true, 0);
            ProgBox[1].PackStart(ProgAlignment[0], true, true, 0);
            ProgBox[2].PackStart(ProgLabels[3], true, true, 0);
            ProgBox[2].PackStart(ProgLabels[2], true, true, 0);
            ProgBox[2].PackStart(ProgBox[1], true, true, 0);
            ProgBox[3].PackStart(ProgLabels[5], false, false, 0);
            ProgBox[3].PackStart(ProgLabels[6], false, false, 0);
            ProgBox[3].PackStart(ProgLabels[7], false, false, 0);
            ProgBox[3].PackStart(ProgLabels[8], false, false, 0);
            ProgBox[3].PackStart(ProgLabels[9], false, false, 0);
            ProgBox[4].PackStart(ProgAlignment[1], false, false, 0);
            ProgBox[5].PackStart(ProgBox[0], false, false, 0);
            ProgBox[5].PackStart(SpaceLabel[0], false, false, 0);
            ProgBox[5].PackStart(ProgBox[2], false, false, 0);
            ProgBox[5].PackStart(SpaceLabel[1], false, false, 0);
            ProgBox[5].PackStart(ProgBox[3], false, false, 0);
            ProgBox[5].PackStart(SpaceLabel[3], false, false, 0);
            ProgBox[5].PackStart(ProgBox[4], false, false, 0);
        }

        /* Sets the properties of the main program window */
        public static void SetupWindow(ref Gtk.Window MagicWindow, ref Gdk.Color WindowColor, ref Gtk.Box[] ProgBox)
        {
            MagicWindow = new Gtk.Window(Gtk.WindowType.Toplevel);
            MagicWindow.AcceptFocus = false;
            MagicWindow.CanFocus = false;
            MagicWindow.Decorated = false;
            MagicWindow.DefaultHeight = 1366;
            MagicWindow.DefaultWidth = 768;
            MagicWindow.HeightRequest = 1366;
            MagicWindow.WidthRequest = 768;
            MagicWindow.Deletable = false;
            MagicWindow.DestroyWithParent = false;
            MagicWindow.FocusOnMap = false;
            MagicWindow.Gravity = Gdk.Gravity.NorthWest;
            MagicWindow.Modal = false;
            MagicWindow.Resizable = false;
            MagicWindow.SkipPagerHint = true;
            MagicWindow.SkipTaskbarHint = true;
            MagicWindow.Title = "Magic Mirror";
            MagicWindow.TypeHint = Gdk.WindowTypeHint.Normal;
            MagicWindow.WindowPosition = Gtk.WindowPosition.CenterAlways;
            MagicWindow.Visible = true;
            MagicWindow.ModifyBg(Gtk.StateType.Normal, WindowColor);
            MagicWindow.DeleteEvent += ProgWindow.MainWindow_Delete;
            MagicWindow.Add(ProgBox[5]);
            MagicWindow.ShowAll();
        }
    }
}