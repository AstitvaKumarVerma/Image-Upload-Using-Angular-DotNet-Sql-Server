import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-view-image-dialog',
  templateUrl: './view-image-dialog.component.html',
  styleUrls: ['./view-image-dialog.component.css']
})
export class ViewImageDialogComponent {
  imagePath: SafeResourceUrl = '';
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private sanitizer: DomSanitizer, private serice: ApiService) {

  }
  ImageId: any;
  alldata: any;
  img: any;
  ngOnInit() {

    this.ImageId = this.data;
    console.log("Image Id: ", this.ImageId);

    this.GetID(this.ImageId);
  }



  GetID(id: any) {
    this.serice.GetImageById(id).subscribe((res: any) => {
      console.log('res: ',res);

      console.log("Img In Base64String: ", res.image);   // our base^4 image is coming inside res.image

      this.img = res.image;
      this.imagePath = this.sanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,'+ this.img);
    },
    error => {
      console.error('Error fetching image:', error);
    })
  }
}

 
