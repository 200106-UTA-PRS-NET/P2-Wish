import { TestBed, async, inject } from '@angular/core/testing';
import { HttpService } from './http.service';
import{ HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { of } from 'rxjs'; // Add import
import { AppComponent } from './app.component';
import { publicData } from './dataObj';
import { CompilePipeMetadata } from '@angular/compiler';


describe('HttpService', () => {
  let service: HttpService;
  let httpMock: HttpTestingController;
  let pData: publicData;

  // beforeEach() is called before each test spec is run
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [HttpService]/////
    });
    service = TestBed.get(HttpService);//inject version of httpservice
    httpMock = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });


  it('should retrieve posts from the API via GET', () => {
      // mock user
      const userResponse = {
        id: '22',
        name: 'Jerry',
        username: 'jerry123',
        password: 'password',
        email: '123@hotmail.com'
      };

      // http get method checkUserId value is mapped to publicData interface
      service.checkUserId('22').subscribe(pData => {
        expect(pData).toEqual(userResponse);
      })

      
      const request = httpMock.expectOne(`${service.ROOT_URL}22`);

      expect(request.request.method).toBe('GET'); // asserrts that http method call is a http get
      request.flush(userResponse);

  });


  /*
  it('should be created', inject([HttpService], (service: HttpService) => {
    expect(service).toBeTruthy();
  }));
  */

});