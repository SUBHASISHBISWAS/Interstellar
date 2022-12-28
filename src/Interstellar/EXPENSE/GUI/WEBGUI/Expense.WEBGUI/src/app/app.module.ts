import { DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { CardModule } from './card/card.module';
import { LoginModule } from './Login/login.module';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [AppComponent],
  imports: [SharedModule, CardModule, LoginModule],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
