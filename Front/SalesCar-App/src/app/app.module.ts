import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NavComponent } from './nav/nav.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CarroService } from 'src/services/carro.service';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';
import { TituloComponent } from './shared/titulo/titulo.component';
import { CarrosComponent } from './components/carros/carros.component';
import { CarrosDetalheComponent } from './components/carros/carros-detalhe/carros-detalhe.component';
import { CarrosListaComponent } from './components/carros/carros-lista/carros-lista.component';
import { VendasComponent } from './components/vendas/vendas.component';
import { ComprasComponent } from './components/compras/compras.component';
import { RelatoriohtmlComponent } from './components/relatorios/relatoriohtml/relatoriohtml.component';
import { RelatoriopdfComponent } from './components/relatorios/relatoriopdf/relatoriopdf.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

import { NgxSpinnerModule } from 'ngx-spinner';



@NgModule({
  declarations: [
    AppComponent,
    CarrosComponent,
    NavComponent,
    TituloComponent,
    CarrosDetalheComponent,
    CarrosListaComponent,
    VendasComponent,
    ComprasComponent,
    RelatoriohtmlComponent,
    RelatoriopdfComponent,
    DashboardComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule
  ],
  providers: [CarroService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
