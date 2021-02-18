import { Component, OnInit } from '@angular/core';
import { AracService } from '../services/arac.service';
import { HomeService } from '../services/home.service';
import { Konum } from '../services/konum';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HomeComponent implements OnInit {


  konumlar : Konum[]=[]
  kuzey : Konum[]=[]
  guney : Konum[]=[]
  dogu : Konum[]=[]
  bati : Konum[]=[]

  doluYer = 0
  bosYer = 0

  constructor(private homeServisi:HomeService,private aracServisi:AracService) { 
    this.homeServisi.KonumlariListele().subscribe(data=>{
      this.konumlar = data;
      this.konumlar.forEach(element => {

        if(element.durum == false){
          this.bosYer++
        }
        else{
          this.doluYer++
        }

        if(element.cephe == "Kuzey"){
            this.kuzey.push(element)
        }
        if(element.cephe == "Güney"){
          this.guney.push(element)
        }
        if(element.cephe == "Doğu"){
          this.dogu.push(element)
        }
        if(element.cephe == "Batı"){
          this.bati.push(element)
        }
      });
    });

  }

  yonlendir(id:number=0){
    this.aracServisi.detayYonlendirme(id.toString())
  }

  ngOnInit(): void {
  }

}
