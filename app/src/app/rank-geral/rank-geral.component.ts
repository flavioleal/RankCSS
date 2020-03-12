import {Component, Injectable, OnInit} from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


export interface Food {
  pontuation: number;
}

@Component({
  selector: 'app-rank-geral',
  templateUrl: './rank-geral.component.html',
  styleUrls: ['./rank-geral.component.css']
})

export class RankGeralComponent implements OnInit {
  displayedColumns: string[] = ['index', 'nickname', 'kill', 'death', 'assistance', 'friendlyFire', 'pontuation'];
  lstRankDiario: Food[];
  public blnPontuationDay: boolean = false;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.carregarRankDiario();
  }

  getClass(i){
      return this.lstRankDiario[i].pontuation >= 0 ? 'my-style-blue' : 'my-style-red';
  }

  public carregarRankDiario() {
    this.http.post<any>(`${environment.url}/RankDiario`, { title: 'Retorna Rank Diário' }).subscribe(data => {
      this.lstRankDiario = data;
        this.blnPontuationDay = this.lstRankDiario == null ? false : true;
    })
  }

}
