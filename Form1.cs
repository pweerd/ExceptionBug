namespace TestException {
   public partial class Form1 : Form {
      public Form1 () {
         InitializeComponent ();
      }

      private void Form1_Load (object sender, EventArgs e) {
         Application.ThreadException += OnThreadException;
      }

      static protected void OnThreadException (object sender, ThreadExceptionEventArgs args) {
         try {
            MessageBox.Show (null, args.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         } catch { }
      }

      private void button1_Click (object sender, EventArgs e) {
         File.Open("I dont exist", FileMode.Open); 
      }

      private unsafe void button2_Click (object sender, EventArgs e) {
         char *p = (char*)0x100000000L;
         String x = new string (p, 0, 25);
         *p = ' ';
      }

      private unsafe void button3_Click (object sender, EventArgs e) {
         try {
            char* p = (char*)0x100000000L;
            *p = ' ';
         } catch (Exception err) {
            MessageBox.Show (null, err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}