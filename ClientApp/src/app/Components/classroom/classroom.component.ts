import { Component, OnInit } from '@angular/core';
import { ClassroomService } from 'src/app/services/classroom.service';
import { Classroom } from 'src/app/models/classroom';
import { DataResponse } from 'src/app/models/dataResponse';

@Component({
  selector: 'app-classroom',
  templateUrl: './classroom.component.html',
  styleUrls: ['./classroom.component.css']
})
export class ClassroomComponent implements OnInit {
  classroom: Classroom;
  constructor(private classroomService: ClassroomService) { }

  ngOnInit() {
  }

  getSchools(){

    this.classroomService.getAllClassrooms().subscribe((response: DataResponse) => {

    });

  }

  addSchool(){

    this.classroomService.addClassroom(this.classroom).subscribe((response: DataResponse) => {

    });

  }

}

