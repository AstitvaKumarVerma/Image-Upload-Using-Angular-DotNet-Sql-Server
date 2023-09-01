import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  GetAllImages(){
    return this.http.get<any[]>('https://localhost:7046/api/Main/GetAllImages');
  }

  GetImageById(Id:any){
    return this.http.get<any>('https://localhost:7046/api/Main/GetImageById?id='+Id);
  }

  UploadImage(Data:any){
    return this.http.post<any>('https://localhost:7046/api/Main/UploadImage',Data);
  }
}
