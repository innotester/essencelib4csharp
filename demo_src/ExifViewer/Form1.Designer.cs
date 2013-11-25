namespace ExifViewer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.pictureBoxMainImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxThumbImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(12, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(89, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // pictureBoxMainImage
            // 
            this.pictureBoxMainImage.Location = new System.Drawing.Point(12, 41);
            this.pictureBoxMainImage.Name = "pictureBoxMainImage";
            this.pictureBoxMainImage.Size = new System.Drawing.Size(368, 298);
            this.pictureBoxMainImage.TabIndex = 1;
            this.pictureBoxMainImage.TabStop = false;
            // 
            // pictureBoxThumbImage
            // 
            this.pictureBoxThumbImage.Location = new System.Drawing.Point(420, 62);
            this.pictureBoxThumbImage.Name = "pictureBoxThumbImage";
            this.pictureBoxThumbImage.Size = new System.Drawing.Size(160, 160);
            this.pictureBoxThumbImage.TabIndex = 2;
            this.pictureBoxThumbImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thumbnail";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxThumbImage);
            this.Controls.Add(this.pictureBoxMainImage);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.PictureBox pictureBoxMainImage;
        private System.Windows.Forms.PictureBox pictureBoxThumbImage;
        private System.Windows.Forms.Label label1;
    }
}

