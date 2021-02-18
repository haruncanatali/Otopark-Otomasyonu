import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Arac } from '../services/arac';
import { AracService } from '../services/arac.service';
import { HomeService } from '../services/home.service';
import { Konum } from '../services/konum';

@Component({
  selector: 'app-arac-ekle',
  templateUrl: './arac-ekle.component.html',
  styleUrls: ['./arac-ekle.component.css']
})
export class AracEkleComponent implements OnInit {

  konumlar : Konum[] = []
  arac : Arac = new Arac()


  constructor(private homeServisi:HomeService,private aracServisi:AracService,private router:Router) { }

  ngOnInit(): void {
    this.homeServisi.BosKonumlariGetir().subscribe(veri=>{
      this.konumlar = veri
    });
  }

  aracEkle(form:NgForm){
    this.aracServisi.aracEkle(this.arac).subscribe(
      (res:any)=>{
        this.router.navigateByUrl("/index")
      },
      err=>{
        if(err.status == 400){
          alert(err.erros)
        }
      }
    )
  }

}
