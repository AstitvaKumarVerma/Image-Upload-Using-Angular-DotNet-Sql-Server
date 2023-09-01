import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { ImageListComponent } from './image-list/image-list.component';
import { ViewImageDialogComponent } from './view-image-dialog/view-image-dialog.component';

const routes: Routes = [
  {
    path:'Upload-Image',
    component: ImageUploadComponent
  },
  {
    path:'',
    component: ImageListComponent
  },
  {
    path:'View-Image',
    component: ViewImageDialogComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
