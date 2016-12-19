using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mp3Effects.Options;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;

namespace Mp3Effects.ShellExtensions
{
    [Guid("45ef906e-c6c6-4f0a-b235-f104656bcd68")]
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".mp3")]
    public class PitchMp3ContetMenu : SharpContextMenu
    {
        // <summary>
        /// Determines whether this instance can a shell
        /// context show menu, given the specified selected file list.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance should show a shell context
        /// menu for the specified file list; otherwise, <c>false</c>.
        /// </returns>
        protected override bool CanShowMenu()
        {
            //  We always show the menu.
            return true;
        }

        /// <summary>
        /// Creates the context menu. This can be a single menu item or a tree of them.
        /// </summary>
        /// <returns>
        /// The context menu for the shell context menu.
        /// </returns>
        protected override ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();
            var changePitchMenuItem = new ToolStripMenuItem
            {
                Text = "Change Pitch",
                //Image = Properties.Resources.CountLines,
            };
            menu.Items.Add(changePitchMenuItem);

            for (var i = -6; i <= 6; i++)
            {
                if (i == 0) continue;

                var semitoneText = i.ToString();
                if (i > 0) semitoneText = "+" + semitoneText;

                var pitchMenuItem = new ToolStripMenuItem
                {
                    Text = semitoneText,
                    //Image = Properties.Resources.CountLines,
                    Tag = i
                };

                pitchMenuItem.Click += (sender, args) => PitchMp3File((int)(sender as ToolStripMenuItem).Tag);
                changePitchMenuItem.DropDownItems.Add(pitchMenuItem);
            }
            return menu;
        }

        private void PitchMp3File(int semitones)
        {
            var pipeline = new AudioPipeline();

            var options = new EffectsOptions();
            options.Semitones = semitones;
            foreach (var inputMp3Path in this.SelectedItemPaths)
            {
                options.Mp3File = inputMp3Path;
                pipeline.ApplyEffects(options);
            }
        }
    }
}
