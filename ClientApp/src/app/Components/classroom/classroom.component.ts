import { Component, OnInit } from '@angular/core';
import { ClassroomService } from 'src/app/services/classroom.service';
import { Classroom } from 'src/app/models/classroom';
import { DataResponse } from 'src/app/models/dataResponse';
import { FormGroup } from '@angular/forms';
import { School } from 'src/app/models/school';
import { SchoolService } from 'src/app/services/school.service';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-classroom',
  templateUrl: './classroom.component.html',
  styleUrls: ['./classroom.component.css']
})
export class ClassroomComponent implements OnInit {
  classroom = new Classroom();
  submitted = false;
  classroomForm: FormGroup;
  schools: any;
  schoolName: string;
  constructor(private classroomService: ClassroomService
    , private schoolService: SchoolService) { }

  ngOnInit() {
    console.log(this.classroom);
    this.getSchools();
  }

  getSchools() {
    this.schoolService.getAllSchools().subscribe((response: DataResponse) => {
        this.schools = response.data;
        console.log(this.schools);
    });

  }

  addClassroom(){
    const school = this.schools.filter(s => s.name === this.schoolName);
    this.classroom.School = school[0];

    this.classroomService.addClassroom(this.classroom).subscribe((response: DataResponse) => {
      console.log(response);
    });

  }


}

