import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SchoolService } from '../../services/school.service';
import { School } from '../../models/school';
import { DataResponse } from '../../models/dataResponse';

@Component({
  selector: 'app-school',
  templateUrl: './school.component.html',
  styleUrls: ['./school.component.css']
})
export class SchoolComponent implements OnInit {
  school = new School();  
  submitted = false;
  schoolForm: FormGroup;

  constructor(private schoolService: SchoolService
  ) { }

  ngOnInit() {
  }

  addSchool() {
    this.schoolService.addSchool(this.school).subscribe((response: DataResponse) => {
      console.log(response);
    });

  }

}
