import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarrosComponent } from './carros/carros.component';
import { ComprasComponent } from './compras/compras.component';
import { VendasComponent } from './vendas/vendas.component';

const routes: Routes = [
  { path : 'carros', component: CarrosComponent},
  { path : 'compras', component: ComprasComponent},
  { path : 'vendas', component: VendasComponent},
  { path : '', redirectTo: 'carros', pathMatch:'full'},
  { path : '**', redirectTo: 'carros', pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
