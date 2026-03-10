import { useEffect, useState } from "react";
import axiosInstance from "../../../services/axiosInstance";

const ClothingGallery = () => {    
    const [ categories, setCategories ] = useState<string[]>([]);

  useEffect(() => {
    axiosInstance
      .get("/category")
      .then((response) => setCategories(response.data.categories))
      .catch((error) => console.error(error));
  }, []);

    return (<div>
        Categories
        {categories.map(category => (
            <div>{category}</div>
        ))}
    </div>
    );
};

export default ClothingGallery;