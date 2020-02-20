import { TestBed, async, inject } from '@angular/core/testing';
import { HttpService } from './http.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { EmailValidator } from '@angular/forms';



describe('HttpService', () => {
  let service: HttpService;
  let httpMock: HttpTestingController;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [HttpService]
    });

    service = TestBed.inject(HttpService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get userID', () =>{
      const userResponse = {

        id: '22',
        name: 'Jerry',
        username: 'jerry123',
        password: 'password',
        email: '123@hotmail.com'
      };
    service.checkUserId('22').subscribe(publicData => {
      expect(publicData).toEqual(userResponse);
    })
    
  });
});


