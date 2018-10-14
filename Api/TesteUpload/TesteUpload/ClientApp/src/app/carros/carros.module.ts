import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaCarrosComponent } from './lista-carros/lista-carros.component';
import { CadastraCarrosComponent } from './cadastra-carros/cadastra-carros.component';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [ListaCarrosComponent, CadastraCarrosComponent],
})
export class CarrosModule { }
