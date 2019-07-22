﻿using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace AlbanianXrm.EarlyBound.Helpers
{
    internal class FilePathEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            var options = context.Instance as Options;
            if (value != null)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.ValidateNames = false;
                    dialog.CheckFileExists = false;
                    dialog.CheckPathExists = true;
                    dialog.Filter = options.Language == LanguageEnum.CS ? "C# (*.cs)|*.cs" : "Visual Basic (*.vb)|*.vb";

                    dialog.FileName = value as string;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        return dialog.FileName;
                    }
                }
            }
            return value; // can also replace the wrapper object here
        }
    }
}