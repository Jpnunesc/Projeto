import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ListaCarrosComponent } from './carros/lista-carros/lista-carros.component';
import { CadastraCarrosComponent } from './carros/cadastra-carros/cadastra-carros.component';
 import { CarroService } from '../services/carro-service';
import { HttpModule } from '@angular/http';
import { CadastraEventosComponent } from './eventos/cadastra-eventos/cadastra-eventos.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ListaCarrosComponent,
    CadastraCarrosComponent,
    CadastraEventosComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'carros', component: CadastraCarrosComponent },
      { path: 'eventos', component: CadastraEventosComponent },
    ])
  ],
  providers: [CarroService],
  bootstrap: [AppComponent]
})
export class AppModule { }
