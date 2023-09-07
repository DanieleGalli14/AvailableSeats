using System.Windows.Forms;

namespace Available_Seats
{
    internal class CloseConfirm
    {
        public static bool Confirm()
        {
            DialogResult result = MessageBox.Show("Confermi di voler uscire dall'applicazione?", "Esci", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return (result == DialogResult.Yes) ;
        }
    }

    
}
