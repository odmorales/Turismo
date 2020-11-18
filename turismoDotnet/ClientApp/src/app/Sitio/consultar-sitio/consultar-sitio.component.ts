import { Component, OnInit } from '@angular/core';
import { SitioService } from '../../services/sitio.service';
import { Sitio} from '../models/sitio';
@Component({
  selector: 'app-consultar-sitio',
  templateUrl: './consultar-sitio.component.html',
  styleUrls: ['./consultar-sitio.component.css']
})
export class ConsultarSitioComponent implements OnInit {
  
  sitios:Sitio[];
  constructor(private sitioService:SitioService) { }

  ngOnInit() {
    this.sitioService.get().subscribe(result => {
      this.sitios = result;
    })
  }

}
