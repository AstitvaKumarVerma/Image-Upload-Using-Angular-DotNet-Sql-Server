import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { ViewImageDialogComponent } from '../view-image-dialog/view-image-dialog.component';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {
  images: any[] = [];

  constructor(private dialog: MatDialog, private serviceCall:ApiService, private http: HttpClient, private sanitizer: DomSanitizer) {}

  ngOnInit(): void {
    this.fetchImages();
  }

  fetchImages() {
    this.serviceCall.GetAllImages().subscribe((response) => {
        // Loop through images and sanitize image data URLs
        this.images = response.map(image => ({
          ...image,
          imageData: this.sanitizer.bypassSecurityTrustUrl(image.imageData)
        }));
      },
      (error) => {
        console.error('Error fetching images:', error);
      }
    );
  }

  openImageDialog(id: any) {
    this.dialog.open(ViewImageDialogComponent, {
      data: id 
    });
  }
}
