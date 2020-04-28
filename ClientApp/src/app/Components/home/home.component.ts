import { Component, OnInit } from '@angular/core';
import { SchoolService } from 'src/app/services/school.service';
import { ClassroomService } from 'src/app/services/classroom.service';
import { DataResponse } from 'src/app/models/dataResponse';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isSchool = false;
  isClassroom = false;
  list: any;

  constructor(private schoolService: SchoolService
    , private classroomService: ClassroomService) { }

  ngOnInit() {
 
  }


  getSchools() {
    this.schoolService.getAllSchools().subscribe((response: DataResponse) => {
      this.isSchool = true;
      this.isClassroom = false;
      this.list = response.data;
      
    });
  }

  getClassrooms(){
    this.classroomService.getAllClassrooms().subscribe((response: DataResponse) => {
      this.isSchool = false;
      this.isClassroom = true;
      this.list = response.data;
    });
  }
}
