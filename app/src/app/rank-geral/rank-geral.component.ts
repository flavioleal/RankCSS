import {Component, Injectable, OnInit} from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http'; 

@Component({
  selector: 'app-rank-geral',
  templateUrl: './rank-geral.component.html',
  styleUrls: ['./rank-geral.component.css']
})

export class RankGeralComponent implements OnInit {

  displayedColumns: string[] = ['index', 'nickname', 'kill', 'death', 'assistance', 'pontuation'];
  lstRankDiario: any[];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.carregarRankDiario();
  }

  public carregarRankDiario() {
    this.http.post<any>('http://localhost:56559/RankDiario', { title: 'Retorna Rank Diário' }).subscribe(data => {
      this.lstRankDiario = data;       
    })
  }

}
