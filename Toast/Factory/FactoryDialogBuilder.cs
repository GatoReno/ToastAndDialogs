using System;
using Android.Content;
using Toast.Enums;

namespace Toast.Factory
{
    
    public static class FactoryDialogBuilder
    {        
        public static AndroidX.AppCompat.App.AlertDialog.Builder CreateAlertDialog
            (Context context,
            string title,
            string message,
            string positiveLabel,
            DialogAlerts type,
            EventHandler<DialogClickEventArgs> actionPositive,
            EventHandler<DialogClickEventArgs> actionNegative
            )
        {
            AndroidX.AppCompat.App.AlertDialog.Builder dialog =
                new AndroidX.AppCompat.App.AlertDialog.Builder(context);
            dialog.SetTitle(title)
                  .SetMessage(message)
                  .SetIcon(null)
                  .SetMessage("")
                  .Show();

            if (type == DialogAlerts.OnlyPositive)
            {
                dialog.SetPositiveButton(positiveLabel, actionPositive);
            }
            if (type == DialogAlerts.PositiveAndNegative)
            {
                dialog.SetNegativeButton("Cancel", actionNegative);
            }            

            return dialog;
        }
    }
}
