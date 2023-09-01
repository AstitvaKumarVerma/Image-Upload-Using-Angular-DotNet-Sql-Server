import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent {
  selectedImage: File | undefined;

  constructor(private http: HttpClient, private serviceCall:ApiService, private router: Router) {}

  onFileSelected(event: any) {
    this.selectedImage = event.target.files[0];
  }

  uploadImage() {
    if (this.selectedImage) {
      const formData = new FormData();
      formData.append('ImageFile', this.selectedImage);

      this.serviceCall.UploadImage(formData).subscribe((response:any) => {
          console.log('Image uploaded successfully');
          alert('Image uploaded successfully');

          this.router.navigate([''])
        },

        (error) => {
          console.error('Error uploading image:', error);
        }
      );
    }
  }
}
