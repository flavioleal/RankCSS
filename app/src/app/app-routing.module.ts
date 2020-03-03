import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RankGeralComponent } from './rank-geral/rank-geral.component';


const routes: Routes = [
  { path: '', component: RankGeralComponent },
  { path: 'rank', component: RankGeralComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
