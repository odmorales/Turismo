import { RegistroComponent } from './Sitio/registro/registro.component';
import { ConsultarSitioComponent } from './Sitio/consultar-sitio/consultar-sitio.component'
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'registro',
    component: RegistroComponent
  },
  {
    path: 'consultarSitio',
    component: ConsultarSitioComponent
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
