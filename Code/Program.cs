using System;
using System.Windows.Forms;
using TimerAmbiguous = System.Windows.Forms.Timer;

// Create a new form (window) for the game
Form gameForm = new Form();
gameForm.Text = "My Game Window";
gameForm.Width = 800;
gameForm.Height = 600;

// Create a button and set properties
Button startButton = new Button();
startButton.Text = "Start Game";
startButton.Width = 100;
startButton.Height = 50;
startButton.Left = 350;  // Center button horizontally
startButton.Top = 275;   // Center button vertically

// Set up the button click event
startButton.Click += (sender, e) =>
{
    MessageBox.Show("Game Started!");
};

// Add the button to the form
gameForm.Controls.Add(startButton);

// Create a timer for animation
TimerAmbiguous timer = new TimerAmbiguous();
timer.Interval = 16; // 60 FPS
timer.Tick += (sender, e) =>
{
    gameForm.Invalidate(); // Redraw the form
};
timer.Start();

// Set up the Paint event for drawing to the screen
gameForm.Paint += (sender, e) =>
{
    // Draw a red ball
    e.Graphics.FillEllipse(System.Drawing.Brushes.Red, 100, 100, 50, 50);
};

// Run the application, which will open the form and start the event loop
Application.Run(gameForm);
Console.Write("test");