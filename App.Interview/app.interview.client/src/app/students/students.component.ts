import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';

interface Roster {
  // Adding Roster interface as it's referenced in Student
  // Add more properties as needed when we know more about the Roster model
  id: number;
}

interface Student {
  studentId: number;
  firstName: string;
  lastName: string;
  rosters: Roster[];
}

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  students: Student[] = [];
  loading = true;
  error = '';
  displayedColumns: string[] = ['studentId', 'firstName', 'lastName'];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.fetchStudents();
  }
  fetchStudents() {
    this.http.get<Student[]>('/api/students').subscribe({
      next: (students) => {
        this.students = students.map(student => ({
          ...student,
          // Ensure all required properties exist even if backend doesn't provide them
          firstName: student.firstName || '',
          lastName: student.lastName || '',
          rosters: student.rosters || []
        }));
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Failed to load students';
        this.loading = false;
        console.error('Error fetching students:', error);
      }
    });
  }
}
