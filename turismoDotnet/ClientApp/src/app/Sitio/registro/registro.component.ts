import { Component, OnInit } from '@angular/core';
import { SitioService } from '../../services/sitio.service';
import { Sitio} from '../models/sitio';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  
  sitio:Sitio;
  url:any;
  constructor(private sitioService:SitioService) { }
  ngOnInit() {
    this.sitio = new Sitio();
  }

  onSelectFile(event){
    if(event.target.files && event.target.files[0]){
      var reader= new FileReader();

      reader.readAsDataURL(event.target.files[0]);

      reader.onload = (event) => {
        this.url = event.target.result;
      }
    }
  }
  add() {
    this.sitioService.post(this.sitio).subscribe(s => {
      if (s != null) {
        alert('Registro creado!');
        this.sitio = s;
      }
    });
  }
}
