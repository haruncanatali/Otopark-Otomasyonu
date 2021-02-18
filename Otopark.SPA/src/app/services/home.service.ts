import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Konum } from './konum';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  path = "https://localhost:44320/api/home";
  path1 = "https://localhost:44320/api/home/bosYerler";
  path2 = "https://localhost:44320/api/home/doluYerler";


  constructor(private httpServis:HttpClient) { }

  KonumlariListele():Observable<Konum[]>{
    return this.httpServis.get<Konum[]>(this.path);
  }

  BosKonumlariGetir():Observable<Konum[]>{
    return this.httpServis.get<Konum[]>(this.path1)
  }

  KonumGetir(id:string):Observable<Konum>{
    return this.httpServis.get<Konum>("https://localhost:44320/api/home/konumGetir?id="+id)
  }

}
