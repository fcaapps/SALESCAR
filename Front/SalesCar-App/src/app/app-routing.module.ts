import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarrosDetalheComponent } from './components/carros/carros-detalhe/carros-detalhe.component';
import { CarrosListaComponent } from './components/carros/carros-lista/carros-lista.component';
import { CarrosComponent } from './components/carros/carros.component';
import { ComprasComponent } from './components/compras/compras.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { VendasComponent } from './components/vendas/vendas.component';

const routes: Routes = [
  {path: 'carros', redirectTo: 'carros/lista' },
  {
    path: 'carros', component: CarrosComponent,
    children: [
     { path: 'detalhe/:id', component: CarrosDetalheComponent },
     { path: 'detalhe', component: CarrosDetalheComponent },
     { path: 'lista', component: CarrosListaComponent },
    ]
  },
  { path: 'vendas', component: VendasComponent},
  { path: 'compras', component: ComprasComponent},
  { path: 'dashboard', component: DashboardComponent},
  { path: '', redirectTo: 'dashboard', pathMatch:'full'},
  { path: '**', redirectTo: 'dashboard', pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
