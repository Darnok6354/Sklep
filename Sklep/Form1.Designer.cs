namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            listOfUsers = new ListBox();
            markaTextBox = new TextBox();
            nazwaTextBox = new TextBox();
            cenaTextBox = new TextBox();
            iloscTextBox = new TextBox();
            addButton = new Button();
            searchIdLabel = new Label();
            searchIdTextBox = new TextBox();
            searchIdButton = new Button();
            markaLabel = new Label();
            nazwaLabel = new Label();
            cenaLabel = new Label();
            iloscLabel = new Label();
            searchMarkaLabel = new Label();
            searchMarkaTextBox = new TextBox();
            searchMarkaButton = new Button();
            showAllButton = new Button();
            idToDeleteLabel = new Label();
            idToDeleteTextBox = new TextBox();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 72);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Lista butów";
            // 
            // listOfUsers
            // 
            listOfUsers.FormattingEnabled = true;
            listOfUsers.ItemHeight = 15;
            listOfUsers.Location = new Point(43, 144);
            listOfUsers.Name = "listOfUsers";
            listOfUsers.Size = new Size(247, 259);
            listOfUsers.TabIndex = 2;
            // 
            // markaTextBox
            // 
            markaTextBox.Location = new Point(350, 100);
            markaTextBox.Name = "markaTextBox";
            markaTextBox.Size = new Size(150, 23);
            markaTextBox.TabIndex = 4;
            // 
            // nazwaTextBox
            // 
            nazwaTextBox.Location = new Point(350, 150);
            nazwaTextBox.Name = "nazwaTextBox";
            nazwaTextBox.Size = new Size(150, 23);
            nazwaTextBox.TabIndex = 6;
            // 
            // cenaTextBox
            // 
            cenaTextBox.Location = new Point(350, 200);
            cenaTextBox.Name = "cenaTextBox";
            cenaTextBox.Size = new Size(150, 23);
            cenaTextBox.TabIndex = 8;
            // 
            // iloscTextBox
            // 
            iloscTextBox.Location = new Point(350, 250);
            iloscTextBox.Name = "iloscTextBox";
            iloscTextBox.Size = new Size(150, 23);
            iloscTextBox.TabIndex = 10;
            // 
            // addButton
            // 
            addButton.Location = new Point(350, 280);
            addButton.Name = "addButton";
            addButton.Size = new Size(150, 30);
            addButton.TabIndex = 11;
            addButton.Text = "Dodaj Produkt";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // searchIdLabel
            // 
            searchIdLabel.AutoSize = true;
            searchIdLabel.Location = new Point(550, 72);
            searchIdLabel.Name = "searchIdLabel";
            searchIdLabel.Size = new Size(21, 15);
            searchIdLabel.TabIndex = 12;
            searchIdLabel.Text = "ID:";
            // 
            // searchIdTextBox
            // 
            searchIdTextBox.Location = new Point(550, 100);
            searchIdTextBox.Name = "searchIdTextBox";
            searchIdTextBox.Size = new Size(150, 23);
            searchIdTextBox.TabIndex = 13;
            // 
            // searchIdButton
            // 
            searchIdButton.Location = new Point(550, 130);
            searchIdButton.Name = "searchIdButton";
            searchIdButton.Size = new Size(150, 30);
            searchIdButton.TabIndex = 14;
            searchIdButton.Text = "Szukaj po ID";
            searchIdButton.UseVisualStyleBackColor = true;
            searchIdButton.Click += searchIdButton_Click;
            // 
            // markaLabel
            // 
            markaLabel.AutoSize = true;
            markaLabel.Location = new Point(350, 72);
            markaLabel.Name = "markaLabel";
            markaLabel.Size = new Size(40, 15);
            markaLabel.TabIndex = 3;
            markaLabel.Text = "Marka";
            // 
            // nazwaLabel
            // 
            nazwaLabel.AutoSize = true;
            nazwaLabel.Location = new Point(350, 130);
            nazwaLabel.Name = "nazwaLabel";
            nazwaLabel.Size = new Size(42, 15);
            nazwaLabel.TabIndex = 5;
            nazwaLabel.Text = "Nazwa";
            // 
            // cenaLabel
            // 
            cenaLabel.AutoSize = true;
            cenaLabel.Location = new Point(350, 180);
            cenaLabel.Name = "cenaLabel";
            cenaLabel.Size = new Size(34, 15);
            cenaLabel.TabIndex = 7;
            cenaLabel.Text = "Cena";
            // 
            // iloscLabel
            // 
            iloscLabel.AutoSize = true;
            iloscLabel.Location = new Point(350, 230);
            iloscLabel.Name = "iloscLabel";
            iloscLabel.Size = new Size(61, 15);
            iloscLabel.TabIndex = 9;
            iloscLabel.Text = "Ilość sztuk";
            // 
            // searchMarkaLabel
            // 
            searchMarkaLabel.AutoSize = true;
            searchMarkaLabel.Location = new Point(550, 230);
            searchMarkaLabel.Name = "searchMarkaLabel";
            searchMarkaLabel.Size = new Size(43, 15);
            searchMarkaLabel.TabIndex = 15;
            searchMarkaLabel.Text = "Marka:";
            // 
            // searchMarkaTextBox
            // 
            searchMarkaTextBox.Location = new Point(550, 250);
            searchMarkaTextBox.Name = "searchMarkaTextBox";
            searchMarkaTextBox.Size = new Size(150, 23);
            searchMarkaTextBox.TabIndex = 16;
            // 
            // searchMarkaButton
            // 
            searchMarkaButton.Location = new Point(550, 280);
            searchMarkaButton.Name = "searchMarkaButton";
            searchMarkaButton.Size = new Size(150, 30);
            searchMarkaButton.TabIndex = 17;
            searchMarkaButton.Text = "Szukaj po marce";
            searchMarkaButton.UseVisualStyleBackColor = true;
            searchMarkaButton.Click += searchMarkaButton_Click;
            // 
            // showAllButton
            // 
            showAllButton.Location = new Point(40, 100);
            showAllButton.Name = "showAllButton";
            showAllButton.Size = new Size(150, 30);
            showAllButton.TabIndex = 18;
            showAllButton.Text = "Pokaż Wszystko";
            showAllButton.UseVisualStyleBackColor = true;
            showAllButton.Click += showAllButton_Click;
            // 
            // idToDeleteLabel
            // 
            idToDeleteLabel.AutoSize = true;
            idToDeleteLabel.Location = new Point(750, 72);
            idToDeleteLabel.Name = "idToDeleteLabel";
            idToDeleteLabel.Size = new Size(88, 15);
            idToDeleteLabel.TabIndex = 19;
            idToDeleteLabel.Text = "ID do usunięcia";
            // 
            // idToDeleteTextBox
            // 
            idToDeleteTextBox.Location = new Point(750, 100);
            idToDeleteTextBox.Name = "idToDeleteTextBox";
            idToDeleteTextBox.Size = new Size(150, 23);
            idToDeleteTextBox.TabIndex = 20;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(750, 130);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(150, 30);
            deleteButton.TabIndex = 21;
            deleteButton.Text = "Usuń But";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 450);
            Controls.Add(addButton);
            Controls.Add(iloscTextBox);
            Controls.Add(cenaTextBox);
            Controls.Add(nazwaTextBox);
            Controls.Add(markaTextBox);
            Controls.Add(listOfUsers);
            Controls.Add(label1);
            Controls.Add(markaLabel);
            Controls.Add(nazwaLabel);
            Controls.Add(cenaLabel);
            Controls.Add(iloscLabel);
            Controls.Add(searchIdButton);
            Controls.Add(searchIdTextBox);
            Controls.Add(searchIdLabel);
            Controls.Add(searchMarkaButton);
            Controls.Add(searchMarkaTextBox);
            Controls.Add(searchMarkaLabel);
            Controls.Add(showAllButton);
            Controls.Add(deleteButton);
            Controls.Add(idToDeleteTextBox);
            Controls.Add(idToDeleteLabel);
            Name = "Form1";
            Text = "Sklep - Dodaj Buty";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listOfUsers;
        private TextBox markaTextBox;
        private TextBox nazwaTextBox;
        private TextBox cenaTextBox;
        private TextBox iloscTextBox;
        private Button addButton;
        private Label markaLabel;
        private Label nazwaLabel;
        private Label cenaLabel;
        private Label iloscLabel;
        private Label searchIdLabel;
        private TextBox searchIdTextBox;
        private Button searchIdButton;
        private Label searchMarkaLabel;
        private TextBox searchMarkaTextBox;
        private Button searchMarkaButton;
        private Button showAllButton;
        private Button deleteButton;
        private TextBox idToDeleteTextBox;
        private Label idToDeleteLabel;
    }
}
