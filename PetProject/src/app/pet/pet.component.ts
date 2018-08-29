import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../shared/services/repository.service';
import { PetNamesByOwnerGender } from '../../interfaces/petnamesbyownergender.model';

@Component({
    selector: 'app-pet',
    templateUrl: './pet.component.html',
    styleUrls: ['./pet.component.css']
})
export class PetComponent implements OnInit {

    public catListByGender: PetNamesByOwnerGender[];

    constructor(private repository: RepositoryService) {

    }

    ngOnInit() {
        this.getAllCats();
    }

    public getAllCats() {
        let apiAddress: string = `api/pets`;
        this.repository.getData(apiAddress)
            .subscribe((results: PetNamesByOwnerGender[]) => {

                if (results.length > 0) {
                    // sort list by gender and then by pet name
                    results.sort();
                    results.forEach(element => {
                        if (element.petNames.length > 0) {
                            element.petNames.sort();
                        }
                    });

                    this.catListByGender = results;
                }
            })
            , (error) => {
                // do something with the error
                console.error(error);
            }
    }
}
