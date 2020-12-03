
namespace AppFinal
{
    partial class main_menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.btnBookRentel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBookReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEXIT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnManEmp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManCus = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManBook = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBookData = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "BOOK SHOP SYSTEM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(867, 502);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MENU";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(200, 200);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBookRentel,
            this.btnBookReturn,
            this.btnEXIT});
            this.menuStrip2.Location = new System.Drawing.Point(3, 267);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(861, 232);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // btnBookRentel
            // 
            this.btnBookRentel.Image = global::AppFinal.Properties.Resources.real_estate;
            this.btnBookRentel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBookRentel.Name = "btnBookRentel";
            this.btnBookRentel.Size = new System.Drawing.Size(212, 228);
            this.btnBookRentel.Text = "Book Rentel";
            this.btnBookRentel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnBookReturn
            // 
            this.btnBookReturn.Image = global::AppFinal.Properties.Resources._return;
            this.btnBookReturn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBookReturn.Name = "btnBookReturn";
            this.btnBookReturn.Size = new System.Drawing.Size(212, 228);
            this.btnBookReturn.Text = "Book Return";
            this.btnBookReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEXIT
            // 
            this.btnEXIT.Image = global::AppFinal.Properties.Resources.exit;
            this.btnEXIT.Name = "btnEXIT";
            this.btnEXIT.Size = new System.Drawing.Size(212, 228);
            this.btnEXIT.Text = "Exit";
            this.btnEXIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEXIT.Click += new System.EventHandler(this.btnEXIT_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(200, 200);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManEmp,
            this.btnManCus,
            this.btnManBook,
            this.btnBookData});
            this.menuStrip1.Location = new System.Drawing.Point(3, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 232);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnManEmp
            // 
            this.btnManEmp.Image = global::AppFinal.Properties.Resources.book;
            this.btnManEmp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManEmp.Name = "btnManEmp";
            this.btnManEmp.Size = new System.Drawing.Size(212, 228);
            this.btnManEmp.Text = "Manage Employee";
            this.btnManEmp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManEmp.Click += new System.EventHandler(this.btnManEmp_Click);
            // 
            // btnManCus
            // 
            this.btnManCus.Image = global::AppFinal.Properties.Resources.target;
            this.btnManCus.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManCus.Name = "btnManCus";
            this.btnManCus.Size = new System.Drawing.Size(212, 228);
            this.btnManCus.Text = "Manage Customer";
            this.btnManCus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnManBook
            // 
            this.btnManBook.Image = global::AppFinal.Properties.Resources.information;
            this.btnManBook.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManBook.Name = "btnManBook";
            this.btnManBook.Size = new System.Drawing.Size(212, 228);
            this.btnManBook.Text = "Manage Book";
            this.btnManBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnBookData
            // 
            this.btnBookData.Image = global::AppFinal.Properties.Resources.bookshelf;
            this.btnBookData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBookData.Name = "btnBookData";
            this.btnBookData.Size = new System.Drawing.Size(212, 228);
            this.btnBookData.Text = "Book Data";
            this.btnBookData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 601);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(908, 640);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(908, 640);
            this.Name = "main_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOOK SHOP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnBookRentel;
        private System.Windows.Forms.ToolStripMenuItem btnBookReturn;
        private System.Windows.Forms.ToolStripMenuItem btnEXIT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnManEmp;
        private System.Windows.Forms.ToolStripMenuItem btnManCus;
        private System.Windows.Forms.ToolStripMenuItem btnManBook;
        private System.Windows.Forms.ToolStripMenuItem btnBookData;
    }
}