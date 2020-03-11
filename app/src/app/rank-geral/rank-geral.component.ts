import {Component, Injectable, OnInit} from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


export interface Food {
  calories: number;
  carbs: number;
  fat: number;
  name: string;
  protein: number;
}

@Component({
  selector: 'app-rank-geral',
  templateUrl: './rank-geral.component.html',
  styleUrls: ['./rank-geral.component.css']
})

export class RankGeralComponent implements OnInit {

  // dataSource: Food[] = [
  //   {name: 'Yogurt', calories: 159, fat: 6, carbs: 24, protein: 4},
  //   {name: 'Sandwich', calories: 237, fat: 9, carbs: 37, protein: 4},
  //   {name: 'Eclairs', calories: 262, fat: 16, carbs: 24, protein: 6},
  //   {name: 'Cupcakes', calories: 305, fat: 4, carbs: 67, protein: 4},
  //   {name: 'Gingerbreads', calories: 356, fat: 16, carbs: 49, protein: 4},
  // ];
  displayedColumns: string[] = ['index', 'nickname', 'kill', 'death', 'assistance', 'friendlyFire', 'pontuation'];
  lstRankDiario: Food[];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.carregarRankDiario();
  }

  public carregarRankDiario() {
    this.http.post<any>(`${environment.url}/RankDiario`, { title: 'Retorna Rank Diário' }).subscribe(data => {
      this.lstRankDiario = data;
      console.log(this.lstRankDiario);
    })
  }

}
