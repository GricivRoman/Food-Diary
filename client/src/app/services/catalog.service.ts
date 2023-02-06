import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SexCatalog } from "../shared/Catalogs/SexCatalog";
import { map } from "rxjs/operators";
import { PhysicalActivityCatalog } from "../shared/Catalogs/PhysicalActivityCatalog";

@Injectable()

export class CatalogService {
    constructor(private http: HttpClient) {
    }

    sexCatalog: SexCatalog[] = [];
    physicalActivityCatalog: PhysicalActivityCatalog[] = [];

    loadSexCatalog() : Observable<void> {
        return this.http.get<[]>("/api/catalog/getsexcatalog")
            .pipe(map(data => {
                this.sexCatalog = data;
                return;
            }));
    }

    loadPhysicalActivityCatalog(): Observable<void> {
        return this.http.get<[]>("/api/catalog/getphysicalactivitycatalog")
            .pipe(map(data => {
                this.physicalActivityCatalog = data;
                return;
            }));
    }

   
}