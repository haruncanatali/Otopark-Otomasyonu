import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { Arac } from './arac';

@Injectable({
  providedIn: 'root'
})
export class AracService {

  constructor(private httpServis:HttpClient,private router:Router) {
   }

  path = "https://localhost:44320/api/arac/aracEkle"
  path1 = "https://localhost:44320/api/arac/aracGetir"
  path2 = "https://localhost:44320/api/arac/aracGuncelle"
  path3 = "https://localhost:44320/api/arac/aracSil"
  path4 = "https://localhost:44320/api/arac/faturaEkle"
  path5 = "https://localhost:44320/api/arac/faturaGuncelle"
  aracId = ""

  hedefArac : Arac = new Arac

   httpOptions = {
    headers:new HttpHeaders({
      'Content-Type':'application/json', 
      'Authorization':'Token' 
    })
  }

  aracEkle(arac:Arac):Observable<Arac>{
    return this.httpServis.post<Arac>(this.path,arac,this.httpOptions)
  }

  aracGetir(x:string):Observable<Arac>{
    return this.httpServis.get<Arac>(this.path1+'?id='+x.toString());
  }

  detayYonlendirme(x:string){
    this.aracId = x
    this.router.navigateByUrl('/detay') 
  }

  aracGuncelle(model:Arac){
    return this.httpServis.post<Arac>(this.path2,model,this.httpOptions)
  }

  aracCikisYap(id:number){
    return this.httpServis.post<number>(this.path3,id,this.httpOptions)
  }

  aracFaturaEkleGuncelle(arac:Arac,durum:boolean){
    if(durum){ // güncelleme
      return this.httpServis.post<Arac>(this.path5,arac,this.httpOptions)
    }
    else{ // ekleme
      return this.httpServis.post<Arac>(this.path4,arac,this.httpOptions)
    }
  }
}
