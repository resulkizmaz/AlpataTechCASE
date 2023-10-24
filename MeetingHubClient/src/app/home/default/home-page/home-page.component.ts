import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent implements OnInit, OnDestroy {

  constructor(private auth:AuthenticationService) {
    
  }

  ngOnSubscribe = new Subject();
  ngOnInit(): void {
  }


  ngOnDestroy(): void {
    this.ngOnSubscribe.next(true);
    this.ngOnSubscribe.complete();
  }
}
