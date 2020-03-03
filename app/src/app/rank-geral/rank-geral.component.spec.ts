/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RankGeralComponent } from './rank-geral.component';

describe('RankGeralComponent', () => {
  let component: RankGeralComponent;
  let fixture: ComponentFixture<RankGeralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RankGeralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RankGeralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
