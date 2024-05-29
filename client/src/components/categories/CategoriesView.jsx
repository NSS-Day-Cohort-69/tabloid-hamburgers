import { useEffect, useState } from "react";
import { getAllCategories } from "../../managers/categories";
import "./Categories.css";
import { useNavigate } from "react-router-dom";

export const CategoriesView = () => {
  const [allCategories, setAllCategories] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    getAllCategories().then(setAllCategories);
  }, []);

  return (
    <main>
      <div className="CategoriesView-div-maincontainer">
        <button
          className="CategoriesView-btn-createbutton"
          onClick={() => {
            navigate("create");
          }}
        >
          Create
        </button>
        {allCategories.map((c) => {
          return <article key={c.id}>{c.categoryName}</article>;
        })}
      </div>
    </main>
  );
};
