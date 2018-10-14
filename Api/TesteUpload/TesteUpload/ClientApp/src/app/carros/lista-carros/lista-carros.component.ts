import { Component, OnInit } from '@angular/core';
import { CarroModel } from '../../../models/carros-model';
import { CarroService } from '../../../services/carro-service';

@Component({
  selector: 'app-lista-carros',
  templateUrl: './lista-carros.component.html',
  styleUrls: ['./lista-carros.component.css']
})
export class ListaCarrosComponent implements OnInit {

  formSearchCarro: CarroModel = new CarroModel();
  urlPrincipal = '';
  constructor( private serviceCarro: CarroService) { }

  ngOnInit() {
    this.search() ;
  }

  search() {
    this.serviceCarro.search().subscribe(resp => {
      console.log(resp);
      this.formSearchCarro = resp.object;

    });

  }
}

