import { useState } from "react";
import ConfirmDialog from "../../../../shared/components/ConfirmDialog";
import DeleteIcon from "../../../../shared/components/ui/icons/DeleteIcon";
import EditIcon from "../../../../shared/components/ui/icons/EditIcon";
import { useDeleteClothingItem } from "../../../clothing/hooks/useDeleteClothingItem";
import { useNavigate } from "react-router";

type Props = {
    itemId: string
}

const ItemActions = ({ itemId }: Props) => {
    const [showDialog, setShowDialog] = useState<boolean>(false);

    const navigate = useNavigate();

    const { data, isLoading, error, refetch } = useDeleteClothingItem(itemId);

    return (
        <>
            <div className="flex flex-row gap-5 mr-1">
                <button className=""><EditIcon color="#000000" strokeWidth={1.5} className="w-7.5 h-7.5 cursor-pointer"/></button>
                <button onClick={() => setShowDialog(true)}><DeleteIcon color="#000000" strokeWidth={1.25} className="w-8 h-8 cursor-pointer" /></button>
            </div>     
            {showDialog && 
                <ConfirmDialog message="Are you sure you want to delete this item?" onConfirm={() => {refetch(); navigate(-1)}} onCancel={() => setShowDialog(false)}/>
            } 
        </>
    );
};

export default ItemActions;