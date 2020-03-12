import {Component, Injectable, OnInit} from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


export interface Food {
  nickname: string;
  address: string;
  kill: number;
  assistance: number;
  death: number;
  friendlyFire: number;
  pontuation: number;
}

@Component({
  selector: 'app-rank-geral',
  templateUrl: './rank-geral.component.html',
  styleUrls: ['./rank-geral.component.scss']
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
    this.http.get<any>(`${environment.url}/RankDiario`).subscribe(data => {
      this.lstRankDiario = data;
      console.log(this.lstRankDiario);
      this.blnPontuationDay = this.lstRankDiario == null ? false : true;
    })
  }

}
