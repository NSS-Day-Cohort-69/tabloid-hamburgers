import { useEffect, useState } from "react";
import { getAllCategories } from "../../managers/categories";
import "./Categories.css";

export const CategoriesView = () => {
  const [allCategories, setAllCategories] = useState([]);

  useEffect(() => {
    getAllCategories().then(setAllCategories);
  }, []);

  return (
    <main>
      <div className="CategoriesView-div-maincontainer">
        <button className="CategoriesView-btn-createbutton">Create</button>
        {allCategories.map((c) => {
          return <article key={c.id}>{c.categoryName}</article>;
        })}
      </div>
    </main>
  );
};
